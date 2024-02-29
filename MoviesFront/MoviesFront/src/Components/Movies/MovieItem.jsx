const MovieItem = ({ item }) => {
  return (
    <div className="MovieItem__container">
      <h1> {item.name}</h1>
      <img src={`${item.imageUrl}`} />
      <h5> Duration: {item.duration}</h5>
      <h4> {item.description}</h4>
      <h5> Actors</h5>
      {item.actors.map((itemx, i) => (
        <h4 key={`itemactor${i}${itemx.id}`}>
          {" "}
          {itemx.actor.name}({itemx.characterName})
        </h4>
      ))}
    </div>
  );
};
export default MovieItem;
