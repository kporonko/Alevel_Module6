import React from 'react';
import {IBook} from "../interfaces/IBook";

const Book = (props: {book: IBook}) => {
    return (
        <div className='card mycard'>
            <div className="card-body">
                <h2>{props.book.title}</h2>
                <p className='card-text'>{props.book.description}</p>
                <div>{props.book.releaseYear}</div>
                <div>{props.book.booksAuthors.map(author => (<div key={author.author.authorId}>{author.author.firstName} {author.author.lastName}</div>))}</div>
            </div>
        </div>
    );
};

export default Book;