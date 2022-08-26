import React from 'react'
import '../App.css'
import {Link} from "react-router-dom";
export default function Header() {
  return (
    <div className="header-div">
        <div className='main-label'>
            <Link to={'/'}>Book Store</Link>
        </div>
        <ul>
            <li><Link to={'/addBook'} className='link'>Add Book</Link></li>
            <li>About Us</li>
        </ul>
  </div>
  )
}
