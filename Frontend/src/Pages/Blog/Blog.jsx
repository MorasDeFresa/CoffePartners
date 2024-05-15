import Header from "../../Components/Header/Header";
import Posts from "../../Components/Posts/Posts";

function Blog() {
  return (
    <>
      <section>
        <Header sloganBond={"Blog"} />
      </section>
      <section className="Content">
        <h2>¿Qué hay de nuevo?</h2>
        <Posts />
      </section>
    </>
  );
}

export default Blog;
