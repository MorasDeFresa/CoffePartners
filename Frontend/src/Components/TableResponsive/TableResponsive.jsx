/* eslint-disable react/prop-types */
import { Table, Tbody, Td, Th, Thead, Tr } from "./index";
import { useState, useEffect } from "react";
import "./TableResponsive.Module.css";
function TableResponsive({
  headers,
  data,
  caption = null,
  update,
  remove,
  specific = false,
  view,
  add,
}) {
  const [keysData, setKeysData] = useState([]);

  useEffect(() => {
    setKeysData(Object.keys(data[0]));
  }, []);

  if (data?.length < 1) {
    return (
      <div>
        <br />
        <h2>No se encontraron reportes</h2>
        <button className="btn WithoutMargin" onClick={add}>
          Crea tu primer registro
        </button>
      </div>
    );
  }

  const formatDate = (dateString) => {
    const date = new Date(dateString);
    if (!isNaN(date.getTime())) {
      return date.toLocaleString("es-CO", {
        year: "numeric",
        month: "long",
        day: "numeric",
        hour: "2-digit",
        minute: "2-digit",
        second: "2-digit",
        hour12: false,
      });
    }
    return dateString;
  };

  return (
    <Table className="tableDiv table table-striped table-bordered">
      <caption>{caption}</caption>
      <Thead>
        <Tr>
          {headers?.map((header, index) => (
            <Th key={`HeaderTable_${index}`}>{header}</Th>
          ))}
          <Th>Acciones</Th>
        </Tr>
      </Thead>
      <Tbody className="table-group-divider">
        {data?.map((row, rowIndex) => (
          <Tr key={`RowTable_${rowIndex}`}>
            {keysData?.map((key, cellIndex) => (
              <Td key={`CellTable_${cellIndex}`}>
                {typeof row[key] === "string" && !isNaN(Date.parse(row[key]))
                  ? formatDate(row[key])
                  : row[key]}
              </Td>
            ))}
            <Td>
              {specific ? (
                <div
                  className="btn-group"
                  role="group"
                  aria-label="Basic example"
                >
                  <button
                    type="button"
                    className="WithoutMargin btn btn-warning"
                    onClick={update}
                  >
                    <i className="action bi bi-pencil-square"></i>
                  </button>
                  <button
                    type="button"
                    className="WithoutMargin btn btn-danger"
                    onClick={remove}
                  >
                    <i className="action bi bi-trash3-fill"></i>
                  </button>
                </div>
              ) : (
                <button
                  type="button"
                  className="WithoutMargin btn btn-warning"
                  onClick={() => view(row[keysData[0]])}
                >
                  <i className="action bi bi-eye"> Detalles</i>
                </button>
              )}
            </Td>
          </Tr>
        ))}
      </Tbody>
    </Table>
  );
}

export default TableResponsive;
