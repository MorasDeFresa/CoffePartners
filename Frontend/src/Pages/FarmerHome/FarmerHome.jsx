import NavBar from "../../Components/NavBar/NavBar";
import BannerCard from "../../Components/BannerCard/BannerCard";
import ReactPlayer from "react-player/youtube";
import "./FarmerHome.Module.css";
function FarmerHome() {
  const members = [
    {
      IconURL: "https://www.cenicafe.org/es/images/banner/banner_01.jpg",
      link: "https://www.cenicafe.org/es/publications/sistemas_de_produccion.pdf",
    },
    {
      IconURL:
        "https://colombiaverde.com.co/wp-content/uploads/2023/05/como-sembrar-cafe-organico-en-colombia-1024x576.jpg",
      link: "https://colombiaverde.com.co/geografia/agricultura/como-sembrar-cafe-organico-en-colombia",
    },
    {
      IconURL:
        "https://www.bancolombia.com/wcm/connect/www.bancolombia.com-26918/dc838012-6c9a-48a2-ac19-03eba4e51404/desktop-guia-para-cultivar-cafe.jpg?MOD=AJPERES&CACHEID=ROOTWORKSPACE.Z18_K9HC1202P864E0Q30449MS3000-dc838012-6c9a-48a2-ac19-03eba4e51404-nJkqdgn",
      link: "https://www.bancolombia.com/negocios/actualizate/sostenibilidad/guia-cultivo-cafe-colombia",
    },
  ];

  return (
    <section className="ReportDiv Content">
      <NavBar />
      <h1>Bienvenido Cafetero</h1>
      <div className="divBanner">
        <div className="half">
          <h2>Contenido divulgativo</h2>
          <ReactPlayer
            width={"80%"}
            height={"90%"}
            url="https://youtu.be/ikD-XRKFn-M?si=PatSq0amUzTYYxmx"
          />
        </div>
        <div className="half">
          <h2>Aliados Estrategicos</h2>
          {members?.map((member, index) => (
            <BannerCard
              key={`BannerCard_${index}`}
              IconURl={member?.IconURL}
              link={member?.link}
            />
          ))}
        </div>
      </div>
    </section>
  );
}

export default FarmerHome;
