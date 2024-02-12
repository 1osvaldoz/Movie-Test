import requestAxios from "../../util/requestAxios";
const UserAPI = {
  GetCategoryChannelsByUser: async (token) => {
    const params = { url: "User/GetCategoryChannelsByUser", method: "GET", token };
    var result = await requestAxios(params);
    const { error, data } = result;
    return { error, data };
  },
};
export default UserAPI;
