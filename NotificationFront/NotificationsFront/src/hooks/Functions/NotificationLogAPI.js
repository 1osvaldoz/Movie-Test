import requestAxios from "../../util/requestAxios";
const NotificationLogAPI = {
  POST: async (token, data) => {
    const params = {
      url: "NotificationLog",
      method: "POST",
      data: data,
      token: token,
    };
    var result = await requestAxios(params);
    return result;
  },
  GET: async (token, data) => {
    const params = {
      url: "NotificationLog",
      method: "GET",
      token: token,
    };
    const result = await requestAxios(params);
    return result;
  },
};
export default NotificationLogAPI;
