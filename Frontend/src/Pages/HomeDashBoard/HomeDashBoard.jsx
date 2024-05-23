import "./Homepage.Module.css";
import Login from "../../Components/Login/Login";
import Register from "../../Components/Register/Register";
import NavBar from "../../Components/NavBar/NavBar";
function HomeDashBoard() {
  return (
    <section className="Login">
      <NavBar />
      {location?.pathname == "/sign-in" ? <Login /> : <Register />}
    </section>
  );
}

export default HomeDashBoard;
