import requestAxios from "../../util/requestAxios";
const MoviesAPI = {
  POST: async (token, data) => {
    const params = {
      url: "Movies",
      method: "POST",
      data: data,
      token: token,
    };
    var result = await requestAxios(params);
    return result;
  } 
};
export default MoviesAPI;
