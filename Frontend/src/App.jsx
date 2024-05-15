import { Suspense, lazy } from "react";
import { Route, Routes } from "react-router-dom";
import { Toaster } from "react-hot-toast";
import "./App.css";

//Pages
const HomeDashBoard = lazy(() => import("./Pages/HomeDashBoard/HomeDashBoard"));
const Home = lazy(() => import("./Pages/Home/Home"));
const Blog = lazy(() => import("./Pages/Blog/Blog"));

function App() {
  return (
    <>
      <Toaster />
      <Routes>
        <Route
          path="/sign-in"
          element={
            <Suspense>
              <HomeDashBoard />
            </Suspense>
          }
        />
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
      </Routes>
    </>
  );
}

export default App;
