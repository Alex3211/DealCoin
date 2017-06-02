import { getAsync, postAsync, putAsync, deleteAsync } from '../helper/apiHelper.js'
import AuthService from './AuthService'

const endpoint = "/api/article";

class ArticlesApiService {
    constructor() {

    }

    async getArticleListAsync() {
        return await getAsync(endpoint,AuthService.accessToken);
    }

}

export default new ArticlesApiService()