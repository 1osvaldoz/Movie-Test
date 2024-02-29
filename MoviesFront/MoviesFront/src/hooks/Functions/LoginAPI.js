import requestAxios from "../../util/requestAxios";
const LoginAPI = {
  Login: async (email) => {
    const params = { url: "Login", method: "POST", data: { email } };
    var result = await requestAxios(params);
    const { error, data } = result;
    return { error, data };
  },
};
export default LoginAPI;
