import { LazyLoadComponent } from "react-lazy-load-image-component";
import SingleCard from "../SingleCard/SingleCard";
import data from "../../data/CoffeeProcess.json";
import "./ProcessCoffeeCard.Module.css";

function ProcessCoffeeCard() {
  return (
    <div className="cards">
      {data.Cards?.map((card) => (
        <LazyLoadComponent key={card.title}>
          <SingleCard
            title={card.title}
            imageUrl={card.imageUrl}
            description={card.description}
          ></SingleCard>
        </LazyLoadComponent>
      ))}
    </div>
  );
}

export default ProcessCoffeeCard;
