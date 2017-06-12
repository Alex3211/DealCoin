import * as types from './mutation-types'
import { INCREMENT } from './mutation-types'
import { GETUSER } from './mutation-types'
import { GETSTATUT } from './mutation-types'

export const increment = ({ commit }) => commit(INCREMENT)
export const setuser = ({ commit },user) => commit(GETUSER,user)
export const setStatut = ({ commit },status) => commit(GETSTATUT,status)

/**
 * Notify when an error happens
 * @param {*} param0 
 * @param {*} error 
 */
export function notifyError({ commit }, error) {
    commit(types.ERROR_HAPPENED, `${error.status}: ${error.responseText || error.statusText}`);
}

/**
 * Notify when an action is loading
 * @param {*} param0 
 * @param {boolean} isLoading
 */
export function notifyLoading({ commit }, isLoading) {
    commit(types.SET_IS_LOADING, isLoading);
}

// In order to be DRY, we can combine all of the previous actions in one action...

/**
 * Wraps an async function call in order to handle loading, and errors.
 * In case of error, no exception is thrown: the return value is undefined.
 * @param {*} param0 
 * @param {*} asyncCallback The callback to be executed
 */
export async function executeAsyncRequestOrDefault({ commit }, asyncCallback) {
    commit(types.SET_IS_LOADING, true);

    try {
        return await asyncCallback();
    }
    catch (error) {
        commit(types.ERROR_HAPPENED, `${error.status}: ${error.responseText || error.statusText}`);
        console.error(error);
    }
    finally {
        commit(types.SET_IS_LOADING, false);
    }
}

/**
 * Wraps an async function call in order to handle loading, and errors.
 * In case of error, the error is thrown.
 * @param {*} param0 
 * @param {*} asyncCallback The callback to be executed
 */
export async function executeAsyncRequest({ commit }, asyncCallback) {
    commit(types.SET_IS_LOADING, true);

    try {
        return await asyncCallback();
    }
    catch (error) {
        commit(types.ERROR_HAPPENED, `${error.status}: ${error.responseText || error.statusText}`);
        console.error(error);

        throw error;
    }
    finally {
        commit(types.SET_IS_LOADING, false);
    }
}