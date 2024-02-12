import { useState } from "react";
import requestAxios from "../util/requestAxios";
import CategoryAPI from "./Functions/CategoryAPI";
import LoginAPI from "./Functions/LoginAPI";
import UserAPI from "./Functions/UserAPI";
import NotificationLogAPI from "./Functions/NotificationLogAPI";
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
      setShowLoader(true)
      const { error, data } = await LoginAPI.Login(email);
      if (!error) {
        setUserSession(data);
        setNewData({LogHistoryList:null})
      }
      setShowLoader(false)

      return { error, data };
    },
  };
  const NotificationLogRequest = {
    Post: async (token, data) => {
      const result = NotificationLogAPI.POST(token, data);
      return result;
    },
    Get: async (token) => {
      const result = await NotificationLogAPI.GET(token);
      setNewData({ LogHistoryList: result.data });
    },
  };
  const UserRequest = {
    GetCategoryChannelsByUser: async (token) => {
      const { error, data } = await UserAPI.GetCategoryChannelsByUser(token);
      return { error, data };
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
    NotificationLogRequest,
    UserRequest,
    getData,
    setNewData,
    showLoader,
    setLoader,
  };
};

export default useGlobalState;
