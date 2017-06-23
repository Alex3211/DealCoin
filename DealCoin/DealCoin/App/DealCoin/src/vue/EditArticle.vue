<template>
  <div class="hello">
        <div class="container">
        <img src="../assets/logo.png">
        <div class="row">
            <h1>Editer votre article</h1>
            <form @submit="onSubmit($event)" class="form-horizontal" role="form">
                <div class="form-group">
                    <label class="col-lg-1 control-label">Catégorie:</label>
                    <div class="col-lg-11">
                        <select class="form-control" name="cars">
                            <option id="test" v-for="i in category" v-model="model.categoriesId" v-bind:value="i.categoriesId"> {{i.name}}</option>
                        </select>
                    </div>
                    <br>
                </div> 
                <div class="form-group">
                    <label class="col-lg-1 control-label">Titre:</label>
                    <div class="col-lg-11">
                    <input class="form-control" v-model="model.title" type="text">
                    </div>
                    <br>
                </div> 

                <div class="form-group" id="app">
                    <label class="col-lg-1 control-label">Photo:</label>
                    <div class="col-lg-11">
                            <div v-if="!image">
                            <input type="file" @change="onFileChange" v.model="model.photo">
                        </div>
                        <div v-else>
                            <img width="300" :src="image" />
                            <button @click="removeImage">Supprimer l'image</button>
                        </div>
                    </div>
                    <br>
                </div> 

                <div class="form-group">
                    <label class="col-lg-1 control-label">Description:</label>
                    <div class="col-lg-11">
                    <input class="form-control" v-model="model.desc1" type="text">
                    </div>
                    <br>
                </div> 

                <div class="form-group">
                    <label class="col-lg-1 control-label">Prix: </label>
                    <div class="col-lg-11">
                    <input class="form-control" v-model="model.price" type="text">
                    </div>
                    <br>
                </div>

                <div class="form-group">
                    <label class="col-md-1 control-label"></label>
                    <div class="col-md-11">
                        <input name ="Save" class="btn btn-primary" value="Enregistrer" type="submit">            
                    </div>
                </div>
            </form>
        </div>
    </div>
  </div>
</template>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
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
            categoriesId : this.$route.query.article.categoriesId,
            productsId : this.$route.query.article.productsId,
            title : this.$route.query.article.title,
            photo :this.$route.query.article.photo,
            desc1:this.$route.query.article.desc1,
            price : this.$route.query.article.price,
        },
        model1:{},
        image:this.$route.query.article.photo
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
        e.preventDefault();
        var result = null;
        this.model.categoriesId = document.getElementById("test").value;
        this.model.photo = this.image;
        if (this.model.title.length == 0)
            this.model.title = 0;   
        if(this.model.userId == this.$route.query.article.userId)result = await articleApiService.putArticleListAsync(this.model);
        this.$router.replace('/MyArticles');
    },
    LoadModelUser: async function(email){
        this.model1 = await UserService.getUserAsync(email);
        this.model.userId = this.model1.content.userId;
    }
  }
}
</script>