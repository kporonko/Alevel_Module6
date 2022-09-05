import React from 'react';
import {IBook} from "../interfaces/IBook";
import {Link} from "react-router-dom";

const Book = (props: {book: IBook, onDelete: any}) => {
    return (
        <div className='card mycard'>
            <div className="card-body">
                <Link to={`/book/${props.book.bookId}`}><h2>{props.book.title}</h2></Link>
                <p className='card-text'>{props.book.description}</p>
                <div>{props.book.releaseYear}</div>
                <div>{props.book.booksAuthors.map(author => (<div key={author.author.authorId}>{author.author.firstName} {author.author.lastName}</div>))}</div>
            </div>
            <button onClick={() =>
            {
                window.location.reload();
                props.onDelete(props.book.bookId)
            }} className="my-button">Delete</button>
        </div>
    );
};

export default Book;