import { getAsync, postAsync, putAsync, deleteAsync } from '../helper/apiUser'
import AuthService from './AuthService'

const endpoint = "/api/sales";

class SalesService {
    constructor() {
    }

//informations utilisateur connecté
    async getSalesAsync(email)
    {
        return await getAsync(endpoint, email, AuthService.accessToken);
    }
    async getAllSalesAsync()
    {
        return await getAsync(endpoint, 'All/', AuthService.accessToken);
    }
    async getAllSalesProductsAsync()
    {
        return await getAsync(endpoint, 'AllProducts/', AuthService.accessToken);
    }
    async postSalesAsync(model)
    {
        return await postAsync(endpoint, model.salesId, AuthService.accessToken, model);
    }
    async postSalesAdminAsync(model)
    {
        return await postAsync(endpoint, 'salesAdmin/'+model, AuthService.accessToken, model);
    }
    async putSalesAsync(model)
    {
        return await putAsync(endpoint, model, AuthService.accessToken, model);
    }
//supprimer compte sales
    async deleteSalesAsync(Id)
    {
        return await deleteAsync(endpoint, Id, AuthService.accessToken);
    }
}

export default new SalesService()