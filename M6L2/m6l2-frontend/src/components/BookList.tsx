import React from 'react';
import { IBook } from '../interfaces/IBook';
import Book from "./Book";

const BookList = (props: {books: IBook[]}) => {
    return (
        <div className="flex">
            {props.books.map((book) => (
                <Book key={book.bookId} book={book}/>
            ))}
        </div>
    );
};

export default BookList;