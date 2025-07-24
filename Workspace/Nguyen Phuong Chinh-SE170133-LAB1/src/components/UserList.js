// src/components/UserList.js
import React, { useEffect, useState } from 'react';

const UserList = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetch('/MOCK_DATA.json')
      .then(res => res.json())
      .then(data => setUsers(data));
  }, []);

  return (
    <div className="p-4">
      <h2 className="text-xl font-bold mb-4">User List</h2>
      <table border="1" cellPadding="8" cellSpacing="0">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Email</th>
            <th>Gender</th>
            <th>IP Address</th>
            <th>Country</th>
            <th>Display</th>
            <th>Deleted</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user => (
            <tr key={user.id} style={{ backgroundColor: user.isDelete ? '#fdd' : '#dfd' }}>
              <td>{user.id}</td>
              <td>{user.firstName} {user.lastName}</td>
              <td>{user.email}</td>
              <td>{user.gender}</td>
              <td>{user.ipAddress || '-'}</td>
              <td>{user.country}</td>
              <td>{user.isDisplay ? '✅' : '❌'}</td>
              <td>{user.isDelete ? '🗑️' : ''}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default UserList;
