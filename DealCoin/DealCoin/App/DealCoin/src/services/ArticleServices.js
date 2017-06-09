import { getAsync, getArticleAsync, postAsync, postArticleAsync, putArticleAsync, putAsync, deleteAsync } from '../helper/apiUser.js';
import AuthService from './AuthService';

const endpoint = "/api/article";

class ArticlesApiService {
    constructor() {

    }

    async getArticleListAsync() {
        return await getArticleAsync(endpoint,AuthService.accessToken);
    }
    async GetArticleListByIdAsync(id) {
        return await getAsync(endpoint,'Id/'+id,AuthService.accessToken);
    }
    async postArticleListAsync(model)
    {
        return await postArticleAsync(endpoint, model);
    }
    async putArticleListAsync(model)
    {
        return await putArticleAsync(endpoint, model.userId, AuthService.accessToken, model);
    }
    
    async deleteArticleListAsync(Id)
    {
        return await deleteAsync(endpoint,'delete/'+Id, AuthService.accessToken);
    }
}

export default new ArticlesApiService()