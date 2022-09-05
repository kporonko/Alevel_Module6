import {IAuthor} from "./IAuthor";

export interface IBookAuthor {
    contribution: string,
    releaseYear: number,
    description: string
    author: IAuthor
}