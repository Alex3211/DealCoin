<template>
  <div class="hello">
        <div class="container">
        <div class="col-md-4"></div>
        <div class="col-md-6 panel-body">
            <div class="row">
                <h1>Ajouter un article</h1>
                <h1 v-if="this.error !== ''">{{this.error}}</h1>
                <form @submit="onSubmit($event)" class="form-horizontal row" role="form" >
                    <div class="form-group">
                        <label class="col-md-4 control-label">Catégorie:</label>
                        <div class="col-md-6">
                            <select class="form-control" name="cars">
                                <option id="test" v-for="i in category" v-model="model.categoriesId" v-bind:value="i.categoriesId" v-if="i.parentId!==0">
                                <div class="font1">
                                {{i.name}}
                                </div>
                                
                                </option>
                            </select>
                        </div>
                    </div> 
                    <div class="form-group">
                        <label class=" control-label col-md-4">Titre:</label>
                        <div class="col-md-6">
                        <input class="form-control" v-model="model.title" type="text">
                        </div>
                    </div> 

                    <div class="form-group" >
                        <label class="col-md-4 control-label">Photo:</label>
                        <div class="col-md-6">
                                <div v-if="!image">
                                <input class="btn btn-primary" type="file" @change="onFileChange" v.model="model.photo">
                            </div>
                            <div v-else class='col-md-6'>
                                <img :src="image" class="taille" />
                                <button class="btn btn-primary" @click="removeImage">Remove image</button>
                            </div>
                        </div>
                        <br>
                    </div> 

                    <div class="form-group">
                        <label class="control-label col-md-4">Description:</label>
                        <div class="col-md-6">
                        <textarea  v-model="model.desc1" class="form-control" rows="5" id="Description :"></textarea>
                        </div>
                        <br>
                    </div> 

                    <div class="form-group">
                        <label class=" control-label col-md-4">Prix: </label>
                        <div class="col-md-6">
                        <input class="form-control " v-model="model.price" type="text">
                        </div>
                        <br>
                    </div>

                    <div class="form-group">
                        <label class=" control-label"></label>
                        <div class="">
                            <input name ="Save" class="btn btn-primary" value="Enregistrer" type="submit">            
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
  </div>
</template>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.panel-body{
  background-color: #BFA077;
  border:none;
  -moz-border-radius: 10px;
  -webkit-border-radius: 10px;
  border-radius: 10px;
  -moz-box-shadow: 10px 10px 5px -5px #402E22;
-webkit-box-shadow: 10px 10px 5px -5px #402E22;
-o-box-shadow: 10px 10px 5px -5px #402E22;
box-shadow: 10px 10px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
}
.form-control:focus {
        border-color: #402E22;
        outline: 0;
        -webkit-box-shadow: inset 0 1px 1px #402E22, 0 0 8px #402E22;
        box-shadow: inset 0 1px 1px #402E22, 0 0 8px #402E22;
    }
.font1{
    font-weight: bold !important;
}

.btn-default:active, .btn-default.active, .open > .btn-default.dropdown-toggle {
background-color: #BFA077;
border:none;
 margin-left:5px;
 margin-right:5px;
}
button:hover{
background-color:#BFA077!important;
}
.btn{
 background-color:#BFA077;
 border:none;
}

.taille{
    max-height:150px;
    max-width:150px;
}

h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
div.app {
     text-align: center;

img {
  width: 30%;
  margin: auto;
  display: block;
  margin-bottom: 10px;
}
}
</style>
<script>

</script>
<script>
import UserService from '../services/UserService.js'
import AuthService from '../services/AuthService.js'
import CategoryApiService from '../services/CategoryService.js'
import articleApiService from '../services/ArticleServices.js'

export default {
  data() {
    return {
      category: [],
      model: {
            userId : null,
            categoriesId : null,
            title : null,
            photo :null,
            desc1:null,
            price : null,
        },
        model1:{},
        image:'',
        error: ''
    }
  },
  async mounted(){
      this.email = AuthService.hisEmail();
      this.LoadModelUser(this.email);
      await this.loadCategory();
  },
  methods: {
    loadCategory: async function(){
      var e = await CategoryApiService.getCategoryListAsync();
      this.category = e.content;
    },
    onFileChange(e) {
      var files = e.target.files || e.dataTransfer.files;
      if (!files.length)
        return;
      this.createImage(files[0]);
    },
    createImage(file) {
      var image = new Image();
      var reader = new FileReader();
      var vm = this;

      reader.onload = (e) => {
        vm.image = e.target.result;
      };
      reader.readAsDataURL(file);
    },
    removeImage: function (e) {
      this.image = '';
    },
    onSubmit: async function(e) {
        if(this.isEmpty(this.model1.content.adresse_bitcoin) == false){
            e.preventDefault();
            var result = null;
            this.model.categoriesId = document.getElementById("test").value;
            this.model.photo=this.image;
            if (this.model.title.length == 0)
                this.model.title = 0;   
            result = await articleApiService.postArticleListAsync(this.model);
            this.$router.replace('/MyArticles');
        } else {
            this.error = "Vous n'avez pas d'adresse bitcoin!";
        }

    },
    isEmpty: function(str) {
        return (!str || 0 === str.length);
    },
    LoadModelUser: async function(email){
        this.model1 = await UserService.getUserAsync(email);
        this.model.userId = this.model1.content.userId;
    }
  }
}
</script>