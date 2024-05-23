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
const FarmerReport = lazy(() => import("./Pages/FarmerReport/FarmerReport"));

function App() {
  return (
    <>
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
        </Route>

        {/* Admin Routes */}
        <Route element={<RequireRole authRol={["Admin"]} />}>
          <Route
            path="/developer"
            element={
              <TableResponsive
                data={[
                  {
                    idUser: 2,
                    emailUser: "test@gmail.com",
                    passwordUser: "test0105A#",
                  },
                  {
                    idUser: 5,
                    emailUser: "test",
                    passwordUser: "dGVzdA==",
                  },
                  {
                    idUser: 6,
                    emailUser: "bencito10@gmail.com",
                    passwordUser: "MTIzNzg5QVEzQGE=",
                  },
                  {
                    idUser: 7,
                    emailUser: "admin",
                    passwordUser: "YWRtaW4=",
                  },
                  {
                    idUser: 8,
                    emailUser: "hola@live.com",
                    passwordUser: "SnVhbjEyMzQu",
                  },
                ]}
                caption={"test"}
              />
            }
          />
        </Route>
      </Routes>
    </>
  );
}

export default App;
