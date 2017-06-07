import { getAsync, postAsync, putAsync, deleteAsync } from '../helper/apiHelper.js'
import AuthService from './AuthService'

const endpoint = "/api/article";

class ArticlesApiService {
    constructor() {

    }

    async getArticleListAsync() {
        return await getAsync(endpoint,AuthService.accessToken);
    }
    async postArticleListAsync(model)
    {
        return await postAsync(endpoint, model);
    }
    async putArticleListAsync(model)
    {
        return await putAsync(endpoint, model.userId, AuthService.accessToken, model);
    }
    
    async deleteArticleListAsync(Id)
    {
        return await deleteAsync(endpoint, Id, AuthService.accessToken);
    }
}

export default new ArticlesApiService()