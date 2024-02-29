import requestAxios from "../../util/requestAxios";
const CategoryAPI = {
  getCategories: async (token) => {
    const params = { url: "Category",token };
    var result = await requestAxios(params);
    const { error, data } = result;
    if (error == "") {
      return data;
    }
  },
};
export default CategoryAPI;
