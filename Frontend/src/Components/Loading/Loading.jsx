import "./Loading.Module.css";

function Loading() {
  return (
    <section className="Loading">
      <div className="LoadSpin spinner-border" role="status">
        <span className="visually-hidden">Loading...</span>
      </div>
      <br />
    </section>
  );
}

export default Loading;
