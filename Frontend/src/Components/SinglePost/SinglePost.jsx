/* eslint-disable react-refresh/only-export-components */
/* eslint-disable react/prop-types */
import React from "react";
import {
  LazyLoadImage,
  trackWindowScroll,
} from "react-lazy-load-image-component";
import "./SinglePost.Module.css";

function SinglePost({ title, subtitle, imageUrl, description }) {
  const formattedDescription = description.split("\n").map((line, index) => (
    <React.Fragment key={index}>
      {line}
      <br />
    </React.Fragment>
  ));
  const widthDevice = window.innerWidth;
  let flagImg = false;
  if (widthDevice <= 450) flagImg = true;

  return (
    <div className="postCard card">
      <div className="card-body">
        <h2 className="card-title">{title}</h2>
        {/* <h3 className="card-subtitle mb-2 text-body-secondary">{subtitle}</h3> */}
        <LazyLoadImage
          className="ImgPost"
          src={imageUrl}
          alt="..."
          width={flagImg ? 100 : 300}
        />
        <p className="card-text">{formattedDescription}</p>
      </div>
    </div>
  );
}

export default trackWindowScroll(SinglePost);
