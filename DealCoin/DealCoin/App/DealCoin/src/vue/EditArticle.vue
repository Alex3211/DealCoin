<template>
  <div class="hello">
        <div class="container">
        <img src="../assets/logo.png">
        <div class="row">
            <div class="col-lg-12 text-center">
                <div align="left">
                    <h1>Ajouter un article</h1>

                    <form @submit="onSubmit($event)" class="form-horizontal" role="form">
                    <div class="form-group">
                        <label class="col-lg-1 control-label">Catégorie:</label>
                        <div class="col-lg-3">
                        <input class="form-control" v-model="model.categoriesId" type="text">
                        </div>
                        <br>
                    </div>

                    <div class="form-group">
                        <label class="col-lg-1 control-label">Titre:</label>
                        <div class="col-lg-3">
                        <input class="form-control" v-model="model.title" type="text">
                        </div>
                        <br>
                    </div> 

                    <div class="form-group">
                        <label class="col-lg-1 control-label">Photo:</label>
                        <div class="col-lg-3">
                        <input class="form-control" v-model="model.photo" type="text">
                        </div>
                        <br>
                    </div> 

                    <div class="form-group">
                        <label class="col-lg-1 control-label">Description:</label>
                        <div class="col-lg-3">
                        <input class="form-control" v-model="model.desc1" type="text">
                        </div>
                        <br>
                    </div> 

                    <div class="form-group">
                        <label class="col-lg-1 control-label">Prix: </label>
                        <div class="col-lg-3">
                        <input class="form-control" v-model="model.price" type="text">
                        </div>
                        <br>
                    </div>

                    <div class="form-group">
                        <label class="col-md-1 control-label"></label>
                        <div class="col-md-3">
                            <input name ="Save" class="btn btn-primary" value="Enregistrer" type="submit">            
                        </div>
                    </div>
                </form>
                </div>
            </div>
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
</style>

<script>
import article from './article.vue'
import articleApiService from '../services/ArticleServices.js'
import UserService from '../services/UserService.js'
import AuthService from '../services/AuthService.js'

export default {
  data() {
    return {
      article: [],
      model: {
            userId : null,
            categoriesId : null,
            title : null,
            photo :null,
            desc1:null,
            price : null,
        },
        model1:{}
    
    }
  },
  async mounted(){
      this.email = AuthService.hisEmail();
      this.LoadModelUser(this.email);
  },
  methods: {
    onSubmit: async function(e) {
        e.preventDefault();
        var result = null;
        if (this.model.title.length == 0)
            this.model.title = 0;   
        result = await articleApiService.postArticleListAsync(this.model);
    },
    LoadModelUser: async function(email){
        this.model1 = await UserService.getUserAsync(email);
        this.model.userId = this.model1.content.userId;
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'ArticlePage': article
  }
}
</script>