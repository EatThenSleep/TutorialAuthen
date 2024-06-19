# $${\color{red}Tutorial \space \color{lightblue}Authen \space \color{orange}Author}$$ 
## 0. Basic Authentication (not security, not used now)
- concate string : "username:password" and encode by base 64
- drawback: can easily find this string and decode to know username and password
## 1. Authentication With Cookie 
> [!NOTE]
> Done in 5/6/2023

- Only for Web Application.
- Using Two Layer Authen.
- Using Custom Authorize
## 2. Token Based Authorization
- Web API
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
