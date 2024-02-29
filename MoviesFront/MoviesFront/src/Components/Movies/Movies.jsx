import { useContext, useState } from "react";
import { Button, Table } from "react-bootstrap";
import AppContext from "../../Context/AppContext";
import MovieItem from "./MovieItem";
import "./Movies.css";

function Movies() {
  const { getData } = useContext(AppContext);
  const { moviesList } = getData();
  debugger;
  return (
    <div className="Movie__container">
      {moviesList ? (
        moviesList.length > 0 ? (
          moviesList.map((item, i) => (
            <MovieItem key={`movieItem${i}`} item={item} />
          ))
        ) : (
          <div className="MovieNotFound__container ">
            <img src="https://www.brainpop.com/conceptmap/img/img_noresults_movies.png" />
          </div>
        )
      ) : (
        <div />
      )}
    </div>
  );
}

export default Movies;
