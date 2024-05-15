/* eslint-disable react/prop-types */
/* eslint-disable react-refresh/only-export-components */
import "./Header.Module.css";
import NavBar from "../NavBar/NavBar";

function Header({ sloganNormal, sloganBond }) {
  return (
    <div>
      <section>
        <div className="divHome">
          <NavBar />
          <div className="divTittle">
            <h2 className="slogan">{sloganNormal}</h2>
            <h2 className="slogan" id="idSabor">
              {sloganBond}
            </h2>
          </div>
        </div>
      </section>
    </div>
  );
}

export default Header;
