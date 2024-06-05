# Tutorial Authen 
## 1. Authentication With Cookie
## 2. Authentication With JWT
## 3. Authentication With Manage ToKen (Redis) 

- Refresh Token
- Revoke Token

# Authorization Problem: Solving Manage User In Company Basic
- Authorize with department, user, level

- Table

| ID | Name | ... | ManagerId | IsDirector | DeparmentId | IsHeadOfDepartment |
| ------ | ------ | ------ | ------ | ------ | ------ | ------ |
| ... | ... | ... | ... | ... | ... | ... |


- Collapse Structure Module

<details>
<summary>Director - <b>Member 0</b></summary>
  <details>
  <summary>Head of HR Department - <b>Member 5</b></summary>
  
    - Member 1
    - Member 2
    - ...
  </details>
   <details>
  <summary>Head of Development Department - <b>Member 6</b></summary>
     
    - Member 3
    - Member 4
    - ...
  </details>
</details>
