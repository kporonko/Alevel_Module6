import React from 'react';
import { IBook } from '../interfaces/IBook';
import Book from "./Book";

const BookList = (props: {books: IBook[], onDelete: any}) => {
    return (
        <div className="flex">
            {props.books.map((book) => (
                <Book onDelete={props.onDelete} key={book.bookId} book={book}/>
            ))}
        </div>
    );
};

export default BookList;