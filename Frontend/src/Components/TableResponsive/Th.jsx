import React from "react";

import allowed from "./allowed";

function Th(props) {
  return <th data-testid="th" {...allowed(props)} />;
}

export default Th;
