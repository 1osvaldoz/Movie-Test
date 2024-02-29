import { useState } from "react";
import requestAxios from "../util/requestAxios";
import CategoryAPI from "./Functions/CategoryAPI";
import LoginAPI from "./Functions/LoginAPI";
import MoviesAPI from "./Functions/MoviesAPI";
const useGlobalState = () => {
  const [userSession, setUserSession] = useState({});
  const [data, setData] = useState({});
  const [showLoader, setShowLoader] = useState(false);
  const requestAPI = async (params) => {
    var result = await requestAxios(params);
    return result;
  };
  const CategoryRequest = {
    getCategories: async (token) => {
      return await CategoryAPI.getCategories(token);
    },
  };
  const LoginRequest = {
    Login: async (email) => {
      setShowLoader(true);
      const { error, data } = await LoginAPI.Login(email);
      if (!error) {
        setUserSession(data);
        setNewData({ LogHistoryList: null });
      }
      setShowLoader(false);

      return { error, data };
    },
  };
  const MoviesRequest = {
    Post: async (token, data) => {
      const result = await MoviesAPI.POST(token, data);
      debugger
      setNewData({ moviesList: result.data });
      return result;
    },
  };

  const checkUserSession = () => {
    if (userSession.token) return userSession;
    else return false;
  };
  const setNewData = (newData) => {
    const newobj = { ...data };
    for (const property in newData) {
      if (Array.isArray(newData[property])) {
        newobj[property] = [...newData[property]];
      } else {
        newobj[property] = { ...data[property], ...newData[property] };
        if (newData[property] == null) {
          delete newobj[property];
        }
      }
    }
    setData(newobj);
  };
  const getData = () => {
    return { ...data };
  };
  const setLoader = (loading) => setShowLoader(loading);

  return {
    requestAPI,
    CategoryRequest,
    LoginRequest,
    checkUserSession,
    MoviesRequest,
    getData,
    setNewData,
    showLoader,
    setLoader,
  };
};

export default useGlobalState;
