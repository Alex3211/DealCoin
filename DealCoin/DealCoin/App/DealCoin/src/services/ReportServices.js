import { getAsync, postAsync, putAsync, deleteAsync, putRAsync } from '../helper/apiUser'
import AuthService from './AuthService'

const endpoint = "/api/report";

class ReportService {
    constructor() {
    }

//informations utilisateur connecté
    async getReportrAsync(email)
    {
        return await getAsync(endpoint, email, AuthService.accessToken);
    }
    async getReportByIdAsync(id)
    {
        return await getAsync(endpoint, 'Id/'+id, AuthService.accessToken);
    }
    async getAllReportAsync()
    {
        return await getAsync(endpoint, 'All/', AuthService.accessToken);
    }
    async putReportAsync(model)
    {
        return await putRAsync(endpoint, AuthService.accessToken, model);
    }
}

export default new ReportService()