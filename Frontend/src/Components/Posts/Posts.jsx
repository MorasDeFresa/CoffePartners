import { LazyLoadComponent } from "react-lazy-load-image-component";
import SinglePost from "../SinglePost/SinglePost";
import data from "../../data/PostBlog.json";
import "./Posts.Module.css";

function Posts() {
  return (
    <div className="cards">
      {data.Posts?.map((post) => (
        <LazyLoadComponent key={post.title}>
          <SinglePost
            title={post.title}
            subtitle={post.subtitle}
            imageUrl={post.imageUrl}
            description={post.description}
          ></SinglePost>
        </LazyLoadComponent>
      ))}
    </div>
  );
}

export default Posts;
