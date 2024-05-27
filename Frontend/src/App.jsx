import { Suspense, lazy } from "react";
import { Route, Routes } from "react-router-dom";
import { Toaster } from "react-hot-toast";
import "./App.css";
import Developer from "./Pages/Developer/Developer";
import TableResponsive from "./Components/TableResponsive/TableResponsive";
import { RequireRole, WithoutRole } from "./Components/RequireAuth/RequireAuth";
import LogOut from "./Components/LogOut/LogOut";
//Pages
const HomeDashBoard = lazy(() => import("./Pages/HomeDashBoard/HomeDashBoard"));
const Home = lazy(() => import("./Pages/Home/Home"));
const Blog = lazy(() => import("./Pages/Blog/Blog"));
import FarmerReport from "./Pages/FarmerReport/FarmerReport";
import React, { useState } from "react";
import FarmerHome from "./Pages/FarmerHome/FarmerHome";

export const ModalContext = React.createContext();

function App() {
  const [openModal, setOpenModal] = useState(false);
  const [content, setContent] = useState(<h1>A</h1>);

  return (
    <ModalContext.Provider
      value={[openModal, setOpenModal, content, setContent]}
    >
      <Toaster position="top-right" reverseOrder={false} />
      <Routes>
        {/* Public routes */}
        <Route
          path="/"
          element={
            <Suspense>
              <Home />
            </Suspense>
          }
        />
        <Route
          path="/blog"
          element={
            <Suspense>
              <Blog />
            </Suspense>
          }
        />

        {/* Forms about sign */}
        <Route element={<WithoutRole />}>
          <Route
            path="/sign-in"
            element={
              <Suspense>
                <HomeDashBoard />
              </Suspense>
            }
          />
          <Route
            path="/sign-up"
            element={
              <Suspense>
                <HomeDashBoard />
              </Suspense>
            }
          />
        </Route>

        {/* Farmer and Admin Routes */}
        <Route element={<RequireRole authRol={["Admin", "Farmer"]} />}>
          <Route path="/sign-out" element={<LogOut />} />
        </Route>

        {/* Farmer Routes */}
        <Route element={<RequireRole authRol={["Farmer"]} />}>
          <Route path="/farmer/report/harvest" element={<FarmerReport />} />
          <Route path="/farmer/report/plant" element={<FarmerReport />} />
          <Route path="/farmer" element={<FarmerHome />} />
        </Route>

        {/* Admin Routes */}
        <Route element={<RequireRole authRol={["Admin"]} />}>
          <Route path="/developer" element={<Developer />} />
        </Route>
      </Routes>
    </ModalContext.Provider>
  );
}

export default App;
