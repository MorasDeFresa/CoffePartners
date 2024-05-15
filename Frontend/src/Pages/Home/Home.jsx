/* eslint-disable react-refresh/only-export-components */
import "./Home.Module.css";
import Header from "../../Components/Header/Header";
import ProcessCoffeeCard from "../../Components/ProcessCoffeeCard/ProcessCoffeeCard";

function Home() {
  return (
    <>
      <section>
        <Header sloganNormal={"DESPIERTA CON"} sloganBond={"SABOR"} />
      </section>
      <section className="Content">
        <h2>¿Cómo funciona el proceso del cafe?</h2>
        <ProcessCoffeeCard />
      </section>
    </>
  );
}

export default Home;
