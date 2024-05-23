/* eslint-disable react/prop-types */
import { Table, Tbody, Td, Th, Thead, Tr } from "./index";
import { useState } from "react";
import "./TableResponsive.Module.css";
function TableResponsive({
  headers,
  data,
  caption = null,
  update,
  remove,
  specific = false,
  view,
}) {
  const [keysData] = useState(Object.keys(data[0]));

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
                  id={row[keysData[0]]}
                  className="WithoutMargin btn btn-warning"
                  onClick={(e) => view(e.target.id)}
                >
                  <i className="action bi bi-eye"></i>
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
