import { getAsync, postAsync, putAsync, deleteAsync } from '../helper/apiUser'
import AuthService from './AuthService'

const endpoint = "/api/user";

class UserService {
    constructor() {
    }

//informations utilisateur connecté
    async getUserAsync(email)
    {
        return await getAsync(endpoint, email, AuthService.accessToken);
    }
    async getUserByIdAsync(id)
    {
        return await getAsync(endpoint, 'Id/'+id, AuthService.accessToken);
    }
    async getAllUserAsync()
    {
        return await getAsync(endpoint, 'All/', AuthService.accessToken);
    }
    async postUserAsync(model)
    {
        return await postAsync(endpoint, model.userId, AuthService.accessToken, model);
    }
    async postUserAdminAsync(model)
    {
        return await postAsync(endpoint, 'UserAdmin/'+model, AuthService.accessToken, model);
    }
    async putUserAsync(model)
    {
        return await putAsync(endpoint, model, AuthService.accessToken, model);
    }

    async putUserPassAsync(model)
    {
        return await putAsync(endpoint,'UserPass/'+model, AuthService.accessToken, model);
    }
//supprimer compte user
    async deleteUserAsync(Id)
    {
        return await deleteAsync(endpoint, Id, AuthService.accessToken);
    }
}

export default new UserService()