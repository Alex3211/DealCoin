import { getAsync, postAsync, putAsync, deleteAsync } from '../helper/apiHelper.js'
import AuthService from './AuthService'

const endpoint = "/api/category";

class CategoryApiService {
    constructor() {

    }

    async getCategoryListAsync() {
        return await getAsync(endpoint,AuthService.accessToken);
    }
    async postCategoryListAsync(model)
    {
        return await postAsync(endpoint, model);
    }
    async putCategoryListAsync(model)
    {
        return await putAsync(endpoint, model.userId, AuthService.accessToken, model);
    }
    
    async deleteCategoryListAsync(Id)
    {
        return await deleteAsync(endpoint, Id, AuthService.accessToken);
    }
}

export default new CategoryApiService()