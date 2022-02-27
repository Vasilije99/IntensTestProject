import React, { useState } from 'react'
import './addSkill.css'
import backend from '../../api/backend'
import { useNavigate } from 'react-router-dom'

const AddSkill = () => {
    const navigate = useNavigate();
    const [skill, setSkill] = useState({name:''});

    const addSkill = async () => {
        try {
            await backend.post(`/Skill/addSkill`, skill);
            window.confirm("Skill was added to DB")
            navigate('/');
        } catch (error) {
            alert(error);
        }
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        addSkill();
    }

    return (
        <form className='formTemplate' onSubmit={(e) => handleSubmit(e)}>
            <label>
                Skill name:
                <input type="text" onChange={(e) => setSkill(prevState => ({ ...prevState, name: e.target.value }))} />
            </label>

            <button type='submit'>Submit</button>
        </form>
    )
}

export default AddSkill