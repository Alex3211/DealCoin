<template>
  <div id="app">
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <router-link to="/"><a class="navbar-brand Element" href="#" >dealcoin</a></router-link>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li>
                      <router-link to="/connexion"><a href="#" class="Element">Connection</a></router-link>
                    </li>
                    <li>
                        <router-link to="/apropos"><a href="#" class="Element">A propos</a></router-link>
                    </li> 
                    <li>
                        <router-link to="/articles"><a href="#" class="Element">Articles</a></router-link>
                    </li>
                    <li>
                        <router-link to="/logout">Se déconnecter</router-link>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <img src="./assets/logo.png">
    <router-view></router-view>
  </div>
</template>

<style lang="scss">
  @import 'src/assets/scss/design.scss';
</style>

<script>
export default {
  name: 'app'
}
</script>

<style>
.router-link-active a {
    color:white;
}
.Element{
    color:#9d9d9d;
}
.Element:hover{
    color:white;
}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #9d9d9d;
  margin-top: 60px;
}
</style>
