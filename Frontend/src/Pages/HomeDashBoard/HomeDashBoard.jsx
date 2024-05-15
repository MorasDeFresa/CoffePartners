import "./Homepage.module.css";
import Login from "../../Components/Login/Login";
import NavBar from "../../Components/NavBar/NavBar";

function HomeDashBoard() {
  //Disable Margin and Borders for only this page

  return (
    <>
      <section>
        <NavBar />
        <Login />
      </section>
    </>
  );
}

export default HomeDashBoard;
