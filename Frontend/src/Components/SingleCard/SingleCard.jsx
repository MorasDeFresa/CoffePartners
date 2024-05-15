/* eslint-disable react-refresh/only-export-components */
/* eslint-disable react/prop-types */
import {
  LazyLoadImage,
  trackWindowScroll,
} from "react-lazy-load-image-component";
import "./SingleCard.Module.css";
function SingleCard({ title, imageUrl, description }) {
  return (
    <div className="processCard card">
      <LazyLoadImage
        className="card-img-top"
        src={imageUrl}
        alt="..."
        height={158}
      />
      <div className="card-body">
        <h3 className="card-title">{title}</h3>
        <p className="card-text">{description}</p>
      </div>
    </div>
  );
}

export default trackWindowScroll(SingleCard);
