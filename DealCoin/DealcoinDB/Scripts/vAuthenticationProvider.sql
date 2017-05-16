create view dc.vAuthenticationProvider
as
    select usr.userId, usr.providerName
    from (select userId = u.userId,
              providerName = 'DealCoinDB'
          from dc.users u
          union all
          select userId = u.userId,
              providerName = 'Google'
          from dc.googleUser u) usr
    where usr.userId <> 0;