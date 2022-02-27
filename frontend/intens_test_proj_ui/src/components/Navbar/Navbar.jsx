import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import './navbar.css'

const Navbar = () => {
    const [hamburgerMenu, setHamburgerMenu] = useState(false);

    return (
        <div>
            <button className='hamburgerMenu' onClick={() => setHamburgerMenu(!hamburgerMenu)}>
                <a href="#"><i className="fas fa-bars"></i></a>
            </button>
            <div className={hamburgerMenu ? `sideNavbar` : `navbar`}>
                <Link className='link' to='/' onClick={() => setHamburgerMenu(false)}>Job Candidates</Link>
                <Link className='link' to='/addCandidate' onClick={() => setHamburgerMenu(false)}>Add Job Candidate</Link>
                <Link className='link' to='/addSkill' onClick={() => setHamburgerMenu(false)}>Add Skill</Link>
            </div>
        </div>
    )
}

export default Navbar