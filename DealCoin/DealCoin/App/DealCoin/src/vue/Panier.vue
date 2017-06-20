<template>
    <div class="container">
        <div class="row">
            <div class="col-sm-12 col-md-10 col-md-offset-1">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>Product</th>
                            <th class="text-center">Total</th>
                            <th> </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="a of article" >
                            <td class="col-sm-8 col-md-6">
                            <a class="thumbnail pull-left"> <img class="media-object" src="http://icons.iconarchive.com/icons/custom-icon-design/flatastic-2/72/product-icon.png" style="width: 72px; height: 72px;"> </a>
                                <h4>{{a.title}}</h4>
                                <h5>{{a.desc1}}</h5>
                            </td>
                            <td class="col-sm-1 col-md-1 text-center"><strong>{{a.price}}</strong></td>
                            <td class="col-sm-1 col-md-1">
                            <button type="button" class="btn btn-danger">
                                <span class="glyphicon glyphicon-remove"></span> Remove
                            </button></td>
                        </tr>
                        <tr>
                            <td>   </td>
                            <td><h5>Total Hors Tax</h5></td>
                            <td class="text-right"><h5><strong>{{totaleprix}} €</strong></h5></td>
                        </tr>
                        <tr>
                            <td>   </td>
                            <td><h5>Cout de livraison</h5></td>
                            <td class="text-right"><h5><strong>{{livraison.toFixed(2)}} €</strong></h5></td>
                        </tr>
                        <tr>
                            <td>   </td>
                            <td><h3>Total</h3></td>
                            <td class="text-right"><h3><strong>{{totaletopay.toFixed(2)}} €</strong></h3></td>
                        </tr>
                        <tr>
                            <td>   </td>
                            <td>
                            <router-link to="/articles"><i class="fa fa-list-alt fa-fw"></i>Continue Shopping</router-link>
                            </td>
                            <td>
                            <button type="button" class="btn btn-success">
                                Checkout <span class="glyphicon glyphicon-play"></span>
                            </button></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>
<script>
import Vue from 'vue'
import $ from 'jquery'
import { mapGetters,mapActions } from 'vuex'

export default {
        data() {
            return {
                article:[],
                totaleprix:0,
                tva:1.9,
                livraison:0,
                limitlivraison:49,
                totaletopay:0
            }
        },
        async mounted() {
            await this.loadArticle();
        },
        methods: {
            ...mapGetters(['getArticle']),
            loadArticle: async function(){
                this.article = this.getArticle();
                
                for(var i=0;i<this.article.length;i++){
                this.totaleprix += parseInt(this.article[i].price)
                }
                if(this.totaleprix<=50){
                    this.livraison = this.totaleprix/this.tva
                }else{
                    this.livraison =0
                }
                 
                this.totaletopay = this.livraison+this.totaleprix
            },
            addprice(value){
                this.totaleprix += value;
            }
        }
    }
</script>