/* eslint-disable react/prop-types */
import "./BannerCard.Module.css";

import { LazyLoadImage } from "react-lazy-load-image-component";
function BannerCard({ IconURl, link }) {
  return (
    <div className="banner card" onClick={() => window.open(link, "_blank")}>
      <div className="card-body">
        <LazyLoadImage className="IconUrl" src={IconURl}></LazyLoadImage>
      </div>
    </div>
  );
}

export default BannerCard;
