import { requestApi } from "../../hooks/useApi";
import { useState, useEffect, useContext } from "react";
import TableResponsive from "../TableResponsive/TableResponsive";
import Loading from "../Loading/Loading";
import Modal from "../Modal/Modal";
import { ModalContext } from "../../App";

function PlantReport() {
  const [dataHarvest, setDataHarvest] = useState([{}]);
  const [idPlantReport, setIdPlantReport] = useState(0);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [openModal, setOpenModal] = useContext(ModalContext);

  const generalCaption =
    "Reporte géneral sobre las plantas de la finca, información sobre su posición y ultimo estado.";
  const generalHeaders = [
    "Planta de Cafe",
    "Coordenada X",
    "Coordenada Z",
    "Estado de la planta",
  ];

  const specificCaption =
    "Reporte detallado sobre las plantas y sus diversos estados";
  const specificHeaders = [
    "Id Historial Planta",
    "Estado de la planta",
    "Fecha y hora del reporte",
  ];

  const [metaDataTable, setMetaDataTable] = useState({
    caption: generalCaption,
    headers: generalHeaders,
  });

  const GetReports = async () => {
    try {
      let endpoint = "/api/HistoryPlant";
      if (idPlantReport != 0) {
        endpoint = `/api/HistoryPlant/details/${idPlantReport}`;
        setMetaDataTable({
          caption: specificCaption,
          headers: specificHeaders,
        });
      } else {
        setMetaDataTable({
          caption: generalCaption,
          headers: generalHeaders,
        });
      }
      const { data } = await requestApi({
        typeRequest: "get",
        endPoint: endpoint,
      });
      console.log(data);
      setDataHarvest(data);
      setLoading(false);
    } catch (error) {
      setError(error);
      setLoading(false);
      console.error(error);
    }
  };

  const view = (id) => {
    setLoading(true);
    setIdPlantReport(id);
  };

  useEffect(() => {
    GetReports();
  }, [idPlantReport]);

  if (loading) {
    return <Loading />;
  }

  if (error) {
    return <p>Error loading data: {error.message}</p>;
  }

  if (idPlantReport == 0)
    return (
      <div className="Content">
        {/* <Modal /> */}
        <h1>Reporte general de las plantas</h1>
        {/* <button
          onClick={() => {
            setOpenModal(!openModal);
          }}
        >
          Modal
        </button> */}
        <TableResponsive
          headers={metaDataTable?.headers}
          data={dataHarvest}
          caption={metaDataTable?.caption}
          view={view}
        />
      </div>
    );
  else {
    return (
      <div className="Content">
        <h1>Reporte especifico de la planta con Id {idPlantReport}</h1>
        <button
          className="WithoutMargin btn"
          onClick={() => {
            view(0);
          }}
        >
          Volver al reporte general
        </button>
        <TableResponsive
          headers={metaDataTable?.headers}
          data={dataHarvest}
          caption={metaDataTable?.caption}
          specific={true}
        />
      </div>
    );
  }
}

export default PlantReport;
