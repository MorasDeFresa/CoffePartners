import React from "react";

import allowed from "./allowed";

function Tbody(props) {
  return <tbody data-testid="tbody" {...allowed(props)} />;
}

export default Tbody;
