import {IBookAuthor} from "./IBookAuthor";

export interface IBook {
    bookId:	number,
    title:	string,
    releaseYear: number,
    description: string,
    booksAuthors: IBookAuthor[]
}