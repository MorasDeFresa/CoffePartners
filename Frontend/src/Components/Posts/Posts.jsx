import { LazyLoadComponent } from "react-lazy-load-image-component";
import SinglePost from "../SinglePost/SinglePost";
// import data from "../../data/PostBlog.json";
import { useEffect, useState } from "react";
import axios from "axios";
import Loading from "../Loading/Loading";
import "./Posts.Module.css";

function Posts() {
  const [wait, setWait] = useState(true);
  const [data, setData] = useState([]);
  useEffect(() => {
    axios
      .get(`${import.meta.env.VITE_API_URL}/api/Posts`)
      .then(function (response) {
        setWait(false);
        setData(response.data?.reverse());
      })
      .catch(function (error) {
        setWait(false);
        console.log(error);
      });
  }, []);

  return (
    <>
      {!wait ? (
        <div className="cards">
          {data.length < 1 && (
            <p>
              Parece que no hay actualizaciones, vuelve en otro momento
              (´。＿。｀)
            </p>
          )}
          {data?.map((post) => (
            <LazyLoadComponent key={post.idPost}>
              <SinglePost
                title={post.titlePost}
                subtitle={post.titlePost}
                imageUrl={post.imgUrl}
                description={post.descriptionPost}
              ></SinglePost>
            </LazyLoadComponent>
          ))}
        </div>
      ) : (
        <Loading />
      )}
    </>
  );
}

export default Posts;
