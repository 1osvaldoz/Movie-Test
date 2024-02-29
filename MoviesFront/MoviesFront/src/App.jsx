import useGlobalState from "./hooks/useGlobalState";
import { BrowserRouter, Route, RouterProvider, Routes } from "react-router-dom";
import AppContext from "./Context/AppContext";
import routes from "./Routes/routes";
import Home from "./Components/Home/Home";
import Loader from "./Components/Elements/Loader";
import "./App.css"

function App() {
  const globalState = useGlobalState();

  return (
    <>
      <AppContext.Provider value={globalState}>
        <Loader/>
        <BrowserRouter>
          <Routes>
            <Route index element={<Home />} />
            {routes.map((route, i) => {
              const RComponent = route.element;
              return (
                <Route
                  key={route.path}
                  path={route.path}
                  element={<RComponent />}
                />
              );
            })}
          </Routes>
        </BrowserRouter>
      </AppContext.Provider>
    </>
  );
}

export default App;
