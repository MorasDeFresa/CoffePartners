import NavBar from "../../Components/NavBar/NavBar";
import HarvestReport from "../../Components/HarvestReport/HarvestReport";
import PlantReport from "../../Components/PlantReport/PlantReport";
import "./FarmerReport.Module.css";
import { Navigate } from "react-router-dom";

function FarmerReport() {
  if (
    location.pathname != "/farmer/report/harvest" &&
    location.pathname != "/farmer/report/plant"
  )
    return <Navigate to={"/"} />;

  return (
    <section className="ReportDiv">
      <NavBar />
      {location?.pathname == "/farmer/report/harvest" ? (
        <HarvestReport />
      ) : (
        <PlantReport />
      )}
    </section>
  );
}

export default FarmerReport;
